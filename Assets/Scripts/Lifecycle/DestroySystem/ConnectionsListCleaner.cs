using ConnectionSystem.Connection.Components;

namespace Custom
{
    public class ConnectionsListCleaner
    {
        public void CleanFromLists(Entity.Entity deleted, Entity.Entity listContainer)
        {
           var outgoingList = listContainer.Get<OutgoingConnectionComponent>().OutgoingConnections;
           var incomingList = listContainer.Get<IncomingConnectionComponent>().IncomingConnections;

           if (outgoingList.Contains(deleted))
               outgoingList.Remove(deleted);
           
           if (incomingList.Contains(deleted))
               incomingList.Remove(deleted);
        }
    }
}