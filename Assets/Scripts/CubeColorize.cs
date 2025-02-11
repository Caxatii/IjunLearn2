using UnityEngine;

public class CubeColorize
{
    private Color _default;

    public CubeColorize(Color color)
    {
        _default = color;
    }

    public void Random(Cube cube)
    {
        cube.Material.color = UnityEngine.Random.ColorHSV();
    }

    public void Return(Cube cube)
    {
        cube.Material.color = _default;
    }
}
