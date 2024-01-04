public class TriangleRepository {
    readonly double epsilon = 0.000000001;
    public string getTriangleType(Triangle triangle) {
        if (!isTriangle(triangle)) {
            throw new TriangleNotValidException("Not a triangle");
        }

        if (triangle.A.CompareTo(triangle.B) == 0 && triangle.A.CompareTo(triangle.C) == 0) {
            return "Equilateral";
        }
        else if (triangle.A.CompareTo(triangle.B) == 0 || triangle.A.CompareTo(triangle.C) == 0 || triangle.B.CompareTo(triangle.C) == 0) {
            return "Isosceles";
        }
        else {
            return "Scalene";
        }
    }

    private bool isTriangle(Triangle triangle) {
        //Checking if triangle values are below the tolerance (double precision not being precise).
        if (triangle.A <= epsilon || triangle.B <= epsilon || triangle.C <= epsilon) {
            return false;
        }
        
        //Checking if any two lengths are shorter than the third.
        if ((triangle.A + triangle.B - epsilon).CompareTo(triangle.C) < 0) {
            return false;
        }
        if ((triangle.B + triangle.C - epsilon).CompareTo(triangle.A) < 0) {
            return false;
        }
        if ((triangle.A + triangle.C - epsilon).CompareTo(triangle.B) < 0) {
            return false;
        }
        return true;
    }
}