namespace ConnectionSystem.Connection
{
    public class ConnectionStorage
    {
        private Entity.Entity _connection;
        
        public void SetUp(Entity.Entity connection)
        {
            _connection = connection;
        }
        
        public void Clear() => _connection = null;
        
    }
}