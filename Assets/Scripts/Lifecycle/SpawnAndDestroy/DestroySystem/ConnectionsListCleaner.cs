using Core.Entity;
using GamePlay.ConnectionSystem.Components;

namespace Lifecycle.SpawnAndDestroy.DestroySystem
{
    public class ConnectionsListCleaner
    {
        public void CleanFromLists(Entity deleted, Entity listContainer)
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