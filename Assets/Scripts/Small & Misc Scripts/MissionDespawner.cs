using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionDespawner : MonoBehaviour {

    /// Script Mission Despawner
    /// Script básico criado apenas para remover ou "despawnar" as missões do mapa
    /// Por: Leonardo Delafiori

    #region Startando o timer para despawnar
    void Start () {
        StartCoroutine(DeSpawnTimer());
	}
    #endregion
    #region Despawnando o gameobject
    IEnumerator DeSpawnTimer()
    {
        yield return new WaitForSeconds(8);
        DeSpawn();
    }
    #endregion
    #region função para botao no evento "on click"
    public void DeSpawn()
    {
        //Aqui seria inserido codigo para adicionar pontos antes de deletar esse game object
        MissionManager.instance.lowMissionCount--;
        StopAllCoroutines();
        Destroy(gameObject);
    }
    #endregion
}
