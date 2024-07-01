using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShuffle : MonoBehaviour
{
	private int[] cards_array; // Declarar cards_array como una variable miembro
	private int card_position;
	private bool player_turn;

	// Start is called before the first frame update
	void Start()
	{
		cards_array = GenerateRandomArray(); // Inicializar cards_array
		card_position = 0;
		player_turn = true;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public int GetNextCard()
	{
		if (card_position >= cards_array.Length)
		{
			cards_array = GenerateRandomArray();
			card_position = 0;
		}
		if (player_turn)
		{
			player_turn = false;
		}
		else
		{
			player_turn = true;
			if (DecideAIMovement())
			{
				return cards_array[card_position++];
			}
			else
			{
				return cards_array[card_position++] * -1;
			}
		}
		return cards_array[card_position++];
	}

	int[] GenerateRandomArray()
	{
		int[] array = new int[12] { 1, 1, 2, 2, 3, 5, -1, -1, -2, -2, -3, -5 }; // le voy a subir esto porque lo que ganas y pierdes es una basura
		List<int> tempList = new List<int>(array);
		int[] randomArray = new int[12];

		System.Random random = new System.Random();
		int index = 0;

		while (tempList.Count > 0)
		{
			int randomIndex = random.Next(0, tempList.Count);
			randomArray[index] = tempList[randomIndex];
			tempList.RemoveAt(randomIndex);
			index++;
		}

		return randomArray;
	}

	bool DecideAIMovement()
	{
		System.Random random = new System.Random();
		return random.Next(2) == 0;
	}
}
