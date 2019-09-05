﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    void Awake()
	{
		int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
		if(numMusicPlayer>1){
			Destroy(gameObject);
		}else{
			DontDestroyOnLoad(gameObject);
		}
		
	}
}
