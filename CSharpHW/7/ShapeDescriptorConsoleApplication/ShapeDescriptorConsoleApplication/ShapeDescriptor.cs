namespace ShapeDescriptorConsoleApplication
{
    public class ShapeDescriptor
    {
        public Point[] Coordinates { get; private set; }
        public ShapeType ShapeType { get; private set; }

        public ShapeDescriptor(Point topLefPoint, Point topRightPoint, Point bottomRightPoint, Point bottomLeftPoint)
        {
            Coordinates = new [] {topLefPoint, topRightPoint, bottomRightPoint, bottomLeftPoint};
            if (IsRectangle(topLefPoint, topRightPoint, bottomRightPoint, bottomLeftPoint))
            {
                ShapeType = IsSquare(topLefPoint, bottomRightPoint, bottomLeftPoint)
                    ? ShapeType.Square
                    : ShapeType.Rectangle;
            }
            else
            {
                ShapeType = ShapeType.Quadrangle;
            }
        }

        private bool IsRectangle(Point topLefPoint, Point topRightPoint, Point bottomRightPoint, Point bottomLeftPoint)
        {
            return topLefPoint.Y == topRightPoint.Y &&
                   topRightPoint.X == bottomRightPoint.X &&
                   bottomRightPoint.Y == bottomLeftPoint.Y &&
                   bottomLeftPoint.X == topLefPoint.X;
        }

        private bool IsSquare(Point topLefPoint, Point bottomRightPoint, Point bottomLeftPoint)
        {
            return topLefPoint.Y - bottomLeftPoint.Y == bottomRightPoint.X - bottomLeftPoint.X;
        }

        public ShapeDescriptor(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            Coordinates = new[] { firstPoint, secondPoint, thirdPoint };
            ShapeType = IsIsoscelesTriangle(firstPoint, secondPoint, thirdPoint) 
                        ? ShapeType.IsoscelesTriangle 
                        : ShapeType.Triangle;
        }

        private bool IsIsoscelesTriangle(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            return secondPoint.X - firstPoint.X == thirdPoint.X - secondPoint.X;
        }

        public ShapeDescriptor(Point firstPoint, Point secondPoint, Point thirdPoint, Point forthPoint, Point fifthPoint)
        {
            Coordinates = new[] { firstPoint, secondPoint, thirdPoint, forthPoint, fifthPoint };
            ShapeType = ShapeType.Pentagon;
        }
    }
}
