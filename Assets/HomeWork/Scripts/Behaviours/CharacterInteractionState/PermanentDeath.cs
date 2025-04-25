public class PermanentDeath : IBehaviour
{
    private IDestroyable _enemy;    

    public PermanentDeath(IDestroyable enemy)
        => _enemy = enemy;        

    public void Update()
    {
        _enemy.DestroyObject();
    }
}
