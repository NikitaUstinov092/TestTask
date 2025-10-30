using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConnectionSystem.Connection.Components;
using Entity;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
  [Inject] private IEntityStorage _entityStorage;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      var connections = _entityStorage.GetAllEntities().Where(e => e.HasComponent<ConnectionPointsComponent>());
      Debug.Log(_entityStorage.GetAllEntities().Count());
      foreach (var e in connections)
      {
        e.Get<LineRenderComponent>().LineRenderer.SetPosition(0, e.Get<ConnectionPointsComponent>().StartPoint.position);
        e.Get<LineRenderComponent>().LineRenderer.SetPosition(1, e.Get<ConnectionPointsComponent>().EndPoint.position);
      }
    }
  }
}
