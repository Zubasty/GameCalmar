using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerEndMenu : MonoBehaviour
{
    [SerializeField] private GameObject _endGame;
    [SerializeField] private Text _text;
    private PlayerFinish _playerFinish;
    private PlayerMove _playerMove;
    private void Awake()
    {
        _playerFinish = FindObjectOfType<PlayerFinish>();
        _playerMove = FindObjectOfType<PlayerMove>();
    }
    private void OnEnable()
    {
        _playerFinish.Finished += Win;
        _playerMove.Died += Lose;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Win()
    {
        _endGame.SetActive(true);
        _text.text = "You WIN!";
        _text.color = Color.green;
    }
    private void Lose()
    {
        _endGame.SetActive(true);
        _text.text = "You Lose!";
        _text.color = Color.red;
    }
    private void OnDisable()
    {
        _playerFinish.Finished -= Win;
        _playerMove.GetedDamage -= Lose;
    }
}
