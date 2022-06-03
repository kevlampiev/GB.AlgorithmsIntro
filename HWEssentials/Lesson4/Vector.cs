namespace GeekbrainsAlgorithmsIntro.Lesson4;

public class Vector
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public override bool Equals(object obj)
    {
        var vector = obj as Vector;
        if (vector == null)
            return false;
        return X == vector.X && Y == vector.Y && Z == vector.Z;
    }

    public override int GetHashCode()
    {
        var xHashCode = X.GetHashCode();
        var yHashCode = Y.GetHashCode();
        var zHashCode = Z.GetHashCode();
        return xHashCode * yHashCode * zHashCode;
    }
}