// Requires the Photon Fusion 2 SDK (see docs/04_UNITY_ASSET_INTEGRATION.md).
using System.Threading.Tasks;
using Fusion;
using UnityEngine;

namespace GildedDepths.Net
{
    /// <summary>
    /// Starts a Photon Fusion 2 session in Shared Mode (cheap state replication + Photon Cloud
    /// matchmaking). Friends quick-join by session name; this keeps onboarding under a minute.
    /// </summary>
    public sealed class SessionLauncher : MonoBehaviour
    {
        [SerializeField] private NetworkRunner runnerPrefab;
        [SerializeField] private int maxPlayers = 4;

        private NetworkRunner _runner;

        /// <summary>Create or join a shared session by name (e.g. a friend's room code).</summary>
        public async Task JoinShared(string sessionName)
        {
            _runner = Instantiate(runnerPrefab);
            _runner.ProvideInput = true;

            var result = await _runner.StartGame(new StartGameArgs
            {
                GameMode = GameMode.Shared,           // each client owns its objects; cheap puzzle-state sync
                SessionName = sessionName,
                PlayerCount = Mathf.Clamp(maxPlayers, 2, 4)
                // SceneManager / Scene set up at M1.
            });

            Debug.Log(result.Ok
                ? $"[Fusion] Joined shared session '{sessionName}'."
                : $"[Fusion] Join failed: {result.ShutdownReason}");
        }
    }
}
