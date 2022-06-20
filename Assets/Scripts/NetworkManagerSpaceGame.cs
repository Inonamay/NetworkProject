using UnityEngine;
namespace Mirror.Examples.Pong
{
    public class NetworkManagerSpaceGame : NetworkManager
    {
        [SerializeField] Transform[] _spawnPoints;
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            // add player at correct spawn position
            Transform start = _spawnPoints[0];
            if(_spawnPoints.Length > 1)
            {
                start = _spawnPoints[numPlayers % _spawnPoints.Length];
            }
            
            GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);
        }

    }

}