﻿using System;
using ZoneStateManagementSystem.Components;

namespace AreaStatusSystem
{
    public class EntityAreaStateController: IAreaStateNotifier
    {
        public event Action<AreaState, Entity.Entity> OnAreaStateChanged;
        
        private const AreaState InZoneState = AreaState.InZone;
        private const AreaState OutZoneState = AreaState.OutZone;
        
        public void SetStateInZone(Entity.Entity entity)
        {
            if(!entity.TryGet(out AreaStateComponent areaStatusComponent))
                return;
            
            if (areaStatusComponent.State == InZoneState)
                return;
            
            areaStatusComponent.State = InZoneState;
            
            OnAreaStateChanged?.Invoke(InZoneState, entity);
        }
        
        public void SetStateOutZone(Entity.Entity entity)
        {
            if(!entity.TryGet(out AreaStateComponent areaStatusComponent))
                return;
            
            if (areaStatusComponent.State == OutZoneState)
                return;
            
            areaStatusComponent.State = OutZoneState;
            
            OnAreaStateChanged?.Invoke(OutZoneState, entity);
        }
    }
    
    public interface IAreaStateNotifier
    {
        event Action<AreaState, Entity.Entity> OnAreaStateChanged;
    }
}