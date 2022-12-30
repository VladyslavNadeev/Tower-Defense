namespace Assets.Scripts.Debuffs
{
    public static class DebuffExtensions
    {
        public static IDebuff GetDebuff(this GameTileContentType contentType)
        {
            switch (contentType)
            {
                case GameTileContentType.Ice: return new IceSlower();
                case GameTileContentType.Lava: return new LavaObstacle();
                default: return new EmptyDebuff();
            }
        }

        private class IceSlower : IDebuff
        {
            public void Assign(Enemy enemy)
            {
                throw new System.NotImplementedException();
            }

            public void Delete(Enemy enemy)
            {
                throw new System.NotImplementedException();
            }
        }

        private class LavaObstacle : IDebuff
        {
            public void Assign(Enemy enemy)
            {
                throw new System.NotImplementedException();
            }

            public void Delete(Enemy enemy)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}