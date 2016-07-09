using System;
using System.Collections.Generic;
using AutoMapper;
using BugTrackingSystem.AzureService;
using BugTrackingSystem.Data.Model;
using BugTrackingSystem.Data.Repositories;
using BugTrackingSystem.Service.Models;
using BugTrackingSystem.Service.Models.FormModels;
using BugPriority = BugTrackingSystem.Service.Models.BugPriority;
using BugStatus = BugTrackingSystem.Service.Models.BugStatus;
using UserRole = BugTrackingSystem.Service.Models.UserRole;

namespace BugTrackingSystem.Service.Services
{
    public class BugService : IBugService
    {
        private readonly IBugRepository _bugRepository;
        private readonly IMapper _mapper;
        private readonly QueueService _queueService;

        public BugService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>()
                    .ForMember(uvm => uvm.Role, opt => opt.MapFrom(u => (UserRole)u.UserRoleID));
                cfg.CreateMap<Project, ProjectViewModel>();
                cfg.CreateMap<Bug, BaseBugViewModel>();
                cfg.CreateMap<Bug, BugViewModel>()
                    .ForMember(bvm => bvm.AssignedUser, opt => opt.MapFrom(b => b.User))
                    .ForMember(bgm => bgm.Status, opt => opt.MapFrom(b => (BugStatus)b.StatusID))
                    .ForMember(bgm => bgm.Priority, opt => opt.MapFrom(b => (BugPriority)b.PriorityID));
                cfg.CreateMap<Bug, FullBugViewModel>()
                    .ForMember(fbvm => fbvm.AssignedUser, opt => opt.MapFrom(b => b.User))
                    .ForMember(fbvm => fbvm.Status, opt => opt.MapFrom(b => (BugStatus)b.StatusID))
                    .ForMember(fbvm => fbvm.Priority, opt => opt.MapFrom(b => (BugPriority)b.PriorityID))
                    .ForMember(fbvm => fbvm.Comments, opt => opt.Ignore());
                cfg.CreateMap<CommentModel, CommentViewModel>();
                cfg.CreateMap<BugFormViewModel, Bug>();
            });

            _mapper = config.CreateMapper();
            _queueService = new QueueService();
        }

        public IEnumerable<BaseBugViewModel> GetAllBugs()
        {
            var bugs = _bugRepository.GetAll();
            var bugModels = _mapper.Map<IEnumerable<Bug>, IEnumerable<BaseBugViewModel>>(bugs);
            return bugModels;
        }

        public BaseBugViewModel GetBugById(int bugId)
        {
            var bug = _bugRepository.GetById(bugId);
            var bugModel = _mapper.Map<Bug, BaseBugViewModel>(bug);
            return bugModel;
        }

        public FullBugViewModel GetFullBugById(int bugId)
        {
            var bug = _bugRepository.GetById(bugId);
            var fullbugModel = _mapper.Map<Bug, FullBugViewModel>(bug);
            var tableService = new TableService();
            var comments = tableService.RetrieveAllCommentsForBug(bugId.ToString());

            if (comments.Count != 0)
            {
                fullbugModel.Comments = _mapper.Map<List<CommentModel>, List<CommentViewModel>>(comments);
            }

            return fullbugModel;
        }

        public IEnumerable<BugViewModel> GetAllProjectsBugs(int projectId)
        {
            var allprojectsbugs = _bugRepository.GetMany(b => b.ProjectID == projectId);
            var allprojectbugmodels = _mapper.Map<IEnumerable<Bug>, IEnumerable<BugViewModel>>(allprojectsbugs);
            return allprojectbugmodels;
        }

        public void AddNewBug(int assignedUserId, int projectId, string subject, int number, byte statusId, byte priorityId, string description)
        {
            var bugFormViewModel = new BugFormViewModel()
            {
                AssignedUserID = assignedUserId,
                ProjectID = projectId,
                Subject = subject,
                Number = number,
                StatusID = statusId,
                PriorityID = priorityId,
                Description = description,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };
            var bug = _mapper.Map<BugFormViewModel, Bug>(bugFormViewModel);
            _bugRepository.Add(bug);
            _bugRepository.Save();
        }

        public void UpdateBugStatus(int bugId, BugStatus bugStatus)
        {
            var bug = _bugRepository.GetById(bugId);
            if (bug.StatusID == (byte)bugStatus)
                return;

            var queueMessage = string.Format("yevhen.blinov@gmail.com status {0} {1}", Enum.Parse(typeof(BugStatus), bug.StatusID.ToString()), bugStatus);
            bug.StatusID = (byte) bugStatus;
            _bugRepository.Update(bug);
            _bugRepository.Save();
            _queueService.AddMessageToQueue(queueMessage);
        }

        public void UpdateBugPriority(int bugId, BugPriority bugPriority)
        {
            var bug = _bugRepository.GetById(bugId);
            if(bug.PriorityID == (byte)bugPriority)
                return;

            var queueMessage = string.Format("yevhen.blinov@gmail.com priority {0} {1}", Enum.Parse(typeof(BugStatus), bug.PriorityID.ToString()), bugPriority);
            bug.PriorityID = (byte)bugPriority;
            _bugRepository.Update(bug);
            _bugRepository.Save();
            _queueService.AddMessageToQueue(queueMessage);
        }
    }
}
