namespace Assets.Scripts.Debuffs
{
    public interface IDebuff
    {
        void Assign(Enemy enemy);
        void Delete(Enemy enemy);
    }
}
