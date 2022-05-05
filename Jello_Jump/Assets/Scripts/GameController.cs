using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public bool _isGameOver, _isrestartboardopen, _isSettingBoardOpen, _isResume;
    [SerializeField] GameObject GO_RestartBoard, TouchArea;
    [SerializeField] Transform Background;
    [SerializeField] SpriteRenderer Fail, Dim;
    [SerializeField] SpriteRenderer Restart_board, Restart_restartbtn;
    [SerializeField] SpriteRenderer[] Settings, Characters;
    [SerializeField] Background_InfiniteScrollHandler Background_InfiniteScrollHandler;
    public bool _isReBtn_Active, _isSettingBtn_Active;
    [SerializeField] TextMeshProUGUI score;

    public void GameOver()
    {
        TouchArea.SetActive(false);
        if (!_isrestartboardopen)
        {
            Fail.DOFade(1, 0.5f).SetEase(Ease.OutQuart);
            Dim.DOFade(0.7f, 0.5f).SetEase(Ease.OutQuart);
            Invoke("OpenRestartBoard", 1);
        }
    }


    public void OpenSettingBoard()
    {
        TouchArea.SetActive(false);
        CancelInvoke();
        _isSettingBoardOpen = true;
        _isResume = true;
        if (_isrestartboardopen)
        {
            HideRestartBoard();
            for (int i = 0; i < Settings.Length; i++)
            {
                Settings[i].gameObject.SetActive(true);
                Settings[i].DOFade(1, 0.5f).SetEase(Ease.OutQuart);
            }
        }
        else
        {
            Dim.DOFade(0.7f, 0.5f).SetEase(Ease.OutQuart);
            for (int i = 0; i < Settings.Length; i++)
            {
                Settings[i].gameObject.SetActive(true);
                Settings[i].DOFade(1, 0.5f).SetEase(Ease.OutQuart);
            }
        }
    }

    public void OpenCharacterBoard()
    {
        for (int i = 0; i < Settings.Length; i++)
        {
            Settings[i].DOFade(0, 0.5f).SetEase(Ease.OutQuart).OnComplete(() =>
            {
                Settings[i].gameObject.SetActive(false);
            });
        }

        for (int i = 0; i < Characters.Length; i++)
        {
            Characters[i].gameObject.SetActive(true);
            Characters[i].DOFade(1, 0.5f).SetEase(Ease.OutQuart);
        }
    }


    public void CloseCharacterBoard()
    {
        for (int i = 0; i < Characters.Length; i++)
        {
            Characters[i].DOFade(0, 0.5f).SetEase(Ease.OutQuart).OnComplete(() =>
            {
                Characters[i].gameObject.SetActive(false);
            });
        }
        OpenSettingBoard();
    }


    public void CloseSettingBoard()
    {
        TouchArea.SetActive(true);
        _isSettingBoardOpen = false;
        _isResume = false;
        if (_isrestartboardopen)
        {
            OpenRestartBoard();
            for (int i = 0; i < Settings.Length; i++)
            {
                Settings[i].DOFade(0, 0.5f).SetEase(Ease.OutQuart).OnComplete(() =>
                {
                    Settings[i].gameObject.SetActive(false);
                });
            }
        }
        else
        {
            Dim.DOFade(0, 0.5f).SetEase(Ease.OutQuart);
            for (int i = 0; i < Settings.Length; i++)
            {
                Settings[i].DOFade(0, 0.5f).SetEase(Ease.OutQuart).OnComplete(() =>
                {
                    Settings[i].gameObject.SetActive(false);
                });
            }
        }
    }




    void OpenRestartBoard()
    {
        TouchArea.SetActive(false);
        _isrestartboardopen = true;
        GO_RestartBoard.SetActive(true);
        Restart_board.DOFade(1, 0.5f).SetEase(Ease.OutQuart);
        Restart_restartbtn.DOFade(1, 0.5f).SetEase(Ease.OutQuart);
        Fail.DOFade(0, 0.5f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            Fail.gameObject.SetActive(false);
        });
    }


    void HideRestartBoard()
    {
        TouchArea.SetActive(false);
        _isrestartboardopen = false;
        Restart_board.DOFade(0, 0.5f).SetEase(Ease.OutQuart);
        Restart_restartbtn.DOFade(0, 0.5f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            GO_RestartBoard.SetActive(false);
        });
    }


    public void Restart()
    {
        Score._ScoreAmount = 0;
        score.text = "0";
        TouchArea.SetActive(false);
        Restart_restartbtn.DOFade(0, 0.3f).SetEase(Ease.OutQuart);
        Restart_board.DOFade(0, 0.3f).SetEase(Ease.OutQuart);
        Dim.DOFade(1, 0.3f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }

    private void Update()
    {
        if (_isGameOver && !_isSettingBoardOpen)
        {
            GameOver();
        }
    }

}