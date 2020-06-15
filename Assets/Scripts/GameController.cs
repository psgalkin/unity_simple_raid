using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Character[] playerCharacters;
    public Character[] enemyCharacters;
    public EndGameUI EndUI;
    public InGameUILogic GameUI;

    Character currentTarget;
    bool waitingPlayerInput;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameLoop());
    }

    [ContextMenu("Player Move")]
    public void PlayerMove()
    {
        if (waitingPlayerInput) {
            waitingPlayerInput = false;
            GameUI.SetGameButtonsActive(false);
        }
    }

    [ContextMenu("Switch character")]
    public void SwitchCharacter()
    {
        for (int i = 0; i < enemyCharacters.Length; ++i) { 
            if (enemyCharacters[i] == currentTarget) {
                int start = i;
                ++i;
                for (;i < enemyCharacters.Length; ++i) { 
                    if (enemyCharacters[i].IsDead()) {
                        continue;
                    }

                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(false);
                    currentTarget = enemyCharacters[i];
                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);
                    return;
                }

                for (i = 0; i < start; ++i) { 
                    if (enemyCharacters[i].IsDead()) {
                        continue;
                    }

                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(false);
                    currentTarget = enemyCharacters[i];
                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);
                    return;
                }
            }
        }
    }

    void PlayerWon()
    {
        EndUI.StartWinUI();
    }

    void PlayerLost()
    {
        EndUI.StartLossUI();
    }
    

    Character FirstAliveCharacter(Character[] p_characters)
    {
        foreach(Character ch in p_characters)
        {
            if (ch.isAlive) {
                return ch;
            }
        }
        return null;
    }

    bool CheckEndGame()
    {
        if (FirstAliveCharacter(playerCharacters) == null)
        {
            PlayerLost();
            return true;
        }

        if (FirstAliveCharacter(enemyCharacters) == null)
        {
            PlayerWon();
            return true;
        }

        return false;
    }

    IEnumerator GameLoop()
    {
        while (!CheckEndGame())
        {
            foreach (Character player in playerCharacters) {
                if (!player.isAlive) {
                    continue;
                }

                Character target = FirstAliveCharacter(enemyCharacters);
                if (target == null) {
                    break;
                }
                //player.target = target;
                currentTarget = target;
                currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);

                waitingPlayerInput = true;
                GameUI.SetGameButtonsActive(true);

                while (waitingPlayerInput) { 
                    yield return null;
                }

                currentTarget.GetComponentInChildren<TargetIndicator>().gameObject.SetActive(false);
                player.target = currentTarget;

                player.AttackEnemy();
                while (!player.IsIdle()) {
                    yield return null;
                }
            }

            foreach (Character enemy in enemyCharacters)
            {
                if (!enemy.isAlive)
                {
                    continue;
                }

                Character target = FirstAliveCharacter(playerCharacters);
                if (target == null)
                {
                    break;
                }
                enemy.target = target;

                enemy.AttackEnemy();
                while (!enemy.IsIdle() && !enemy.IsDead()) {
                    yield return null;
                }
            }

        }

        //SetAliveTarget()
    }
}
