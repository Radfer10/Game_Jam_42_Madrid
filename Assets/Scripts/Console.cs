using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Security.Permissions;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    private TMP_Text        tex;
    private string          cmd = "";
    private string          defaultTxt = "Type 'help' to read the instructions, or simply type 'take' or 'deal' to start this war...\n\n>_ ";
    private GameObject[]    updates;
    public  GameObject      gameManager;
    public  bool            waiting = false;
    public  float           counter = 0;
    public  bool            doOnce;
	private int 		    num_towers = 0;
	private GameObject audioManagerObject;
	private AudioMananger audioManager;
	private int num_interations = 0;
    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<TMP_Text>();
        tex.SetText(defaultTxt);
		audioManagerObject = GameObject.Find("Audio Source");
		audioManager = audioManagerObject.GetComponent<AudioMananger>();
    }

    void    take()
    {
		num_towers = gameManager.GetComponent<GameManager>().cards.GetNextCard();
        gameManager.GetComponent<GameManager>().editPlayer(num_towers);
		print_take(num_towers);
        waiting = true;
        doOnce = true;
    }

    void    deal()
    {
		num_towers = gameManager.GetComponent<GameManager>().cards.GetNextCard();
        gameManager.GetComponent<GameManager>().editEnemy(num_towers);
		print_deal(num_towers);
        waiting = true;
        doOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {

            if (Input.GetKeyDown("return"))
            {
                if (cmd.Contains("take"))
                {
                    take();
                }
                else if (cmd.Contains("deal"))
                {
                    deal();
                }
                else if (cmd.Contains("help"))
                {
                        tex.SetText("\n\t    ------H E L P------\nTake: With this command, you take the update for yourself, and one of your towers gets upgraded. By taking this action, you skip your opponent's turn only if you get an update without a sabotaje. If not, you get the virus and lose your turn.\n\nDeal: With this command, you give the update to your opponent, and one of their towers gets upgraded. \n\nclear: clear terminal\n");
                }
                else if (cmd.Contains("42"))
                {
                    tex.SetText(tex.text + "\n(-_-)?\n");
                }
                else
                {
                    tex.SetText(tex.text + "\n" + cmd + ": command not found\n");      
                }
                if (!waiting)
				{
                    tex.SetText(tex.text + "\n>_ ");
				}
				else
				{
                    tex.SetText(tex.text + "\n...\n");
				}
                if (cmd.Contains("clear"))
                    tex.SetText(defaultTxt);
                cmd = "";

            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (cmd.Length > 0)
                {
                    cmd = cmd.Remove(cmd.Length - 1);
                    tex.SetText(tex.text.Remove(tex.text.Length - 1));
                }
            }
            else if (!waiting)
            {
                char[]    c = Input.inputString.ToCharArray();

                if (Input.inputString.Length == 0)
                    ;
                else if (c[0] >= 32 && c[0] <= 127)
                {
                    string  keyPressed = Input.inputString;
                    tex.SetText(tex.text + keyPressed);
                    cmd = cmd + keyPressed;
                }
            }
        }
        if (waiting)
        {
            counter += 1 * Time.deltaTime;
            if (counter > 2 && doOnce)
            {
                tex.SetText(tex.text + "...");
                doOnce = false;
            }
        }
        if (counter > 4)
        {
            waiting = false;
			num_towers = gameManager.GetComponent<GameManager>().cards.GetNextCard();
			gameManager.GetComponent<GameManager>().editEnemy(num_towers);
			num_interations++;
			if (num_interations == 3)
			{
				num_interations = 0;
				tex.SetText(defaultTxt);
			}
			print_enemy(num_towers);
            counter = 0;
            tex.SetText(tex.text + "\n>_ ");
        }
    }

	void print_take(int n)
	{
		if (n > 0)
		{
			audioManager.PlayAudio(0);
			if (n > 1)
				tex.SetText(tex.text + " you gain " + n + " towers :)\n");
			else
				tex.SetText(tex.text + " you gain " + n + " tower :)\n");
		}
		else
		{
			audioManager.PlayAudio(1);
			if (n < -1)
				tex.SetText(tex.text + " you lose " + (n * -1) + " towers :(\n");
			else
				tex.SetText(tex.text + " you lose " + (n * -1) + " tower :(\n");
		}
	}

	void print_deal(int n)
	{
		if (n > 0)
		{
			audioManager.PlayAudio(0);
			if (n > 1)
				tex.SetText(tex.text + " your opponent loses " + n + " towers :)\n");
			else
				tex.SetText(tex.text + " your opponent loses " + n + " tower :)\n");
		}
		else
		{
			audioManager.PlayAudio(1);
			if (n < -1)
				tex.SetText(tex.text + " your opponent gains " + (n * -1) + " towers :(\n");
			else
				tex.SetText(tex.text + " your opponent gains " + (n * -1) + " tower :(\n");
		}
	}

	void print_enemy(int n)
	{
		if (n > 0)
		{
			audioManager.PlayAudio(0);
			if (n > 1)
				tex.SetText(tex.text + "\nyour opponent loses " + n + " towers :)\n");
			else
				tex.SetText(tex.text + "\nyour opponent loses " + n + " tower :)\n");
		}
		else
		{
			audioManager.PlayAudio(1);
			if (n < -1)
				tex.SetText(tex.text + "\nyour opponent gains " + (n * -1) + " towers :(\n");
			else
				tex.SetText(tex.text + "\nyour opponent gains " + (n * -1) + " tower :(\n");
		}
	}
}

