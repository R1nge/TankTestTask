using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
	private Health _health;

	private void Awake ()
	{
		_health = GetComponent<Health>();
		_health.OnDieEvent += Restart;
	}

	private void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}


	private void OnDisable ()
	{
		_health.OnDieEvent -= Restart;
	}
}
