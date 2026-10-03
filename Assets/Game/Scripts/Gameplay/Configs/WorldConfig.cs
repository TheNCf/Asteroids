namespace Game.Scripts.Gameplay.Configs
{
    public class WorldConfig
    {
        public WorldConfig(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float Width { get; private set; }
        public float Height { get; private set; }
    }
}