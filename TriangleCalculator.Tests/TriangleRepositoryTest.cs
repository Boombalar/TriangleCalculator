using Xunit;

public class TriangleTests
{

    TriangleRepository triangleRepository = new ();

    [Fact]
    public void getTriangleType_ReturnsCorrectValue()
    {
        string equilateral = triangleRepository.getTriangleType(new Triangle(3.3, 3.3, 3.3));
        string isosceles = triangleRepository.getTriangleType(new Triangle(3.5, 4.0, 3.5));
        string scalene = triangleRepository.getTriangleType(new Triangle(3.1, 4.2, 5.5));

        Assert.Equal("Equilateral", equilateral);
        Assert.Equal("Isosceles", isosceles);
        Assert.Equal("Scalene", scalene);
    }

    [Fact]
    public void isTriangle_SideIsTooShort() {
        Triangle triangle1 = new Triangle(3.0, 1.0, 1.0);
        Triangle triangle2 = new Triangle(1.0, 3.0, 1.0);
        Triangle triangle3 = new Triangle(1.0, 1.0, 3.0);

        Triangle triangle4 = new Triangle(2.2, 2.2, 4.4);

        Assert.Throws<TriangleNotValidException>(() => triangleRepository.getTriangleType(triangle1));
        Assert.Throws<TriangleNotValidException>(() => triangleRepository.getTriangleType(triangle2));
        Assert.Throws<TriangleNotValidException>(() => triangleRepository.getTriangleType(triangle3));
        Assert.Throws<TriangleNotValidException>(() => triangleRepository.getTriangleType(triangle4));
    }

    [Fact]
    public void isTriangle_NegativeValues() {
        Triangle triangle1 = new Triangle(-3.0, 4.0, 5.0);
        Triangle triangle2 = new Triangle(3.0, -4.0, 5.0);
        Triangle triangle3 = new Triangle(3.0, 4.0, -5.0);

        Assert.Throws<TriangleNotValidException>(() => triangleRepository.getTriangleType(triangle1));
        Assert.Throws<TriangleNotValidException>(() => triangleRepository.getTriangleType(triangle2));
        Assert.Throws<TriangleNotValidException>(() => triangleRepository.getTriangleType(triangle3));
    }
}
