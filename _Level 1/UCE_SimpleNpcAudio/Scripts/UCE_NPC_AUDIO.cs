﻿// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Entity
{
    public AudioClip interactAudio;
    public AudioClip questAudio;

    public void PlayInteractSound()
    {
        AudioSource tempSource = FindObjectOfType<AudioSource>();
        if (tempSource == null) return;

        tempSource.PlayOneShot(interactAudio);
    }

    public void PlayQuestAudio()
    {
        AudioSource tempSource = FindObjectOfType<AudioSource>();
        if (tempSource == null) return;

        tempSource.PlayOneShot(questAudio);
        Debug.Log("Play Quest Audio.");
    }
}

public partial class UINpcDialogue
{
    public void interactAudio()
    {
        Player player = Player.localPlayer;
        if (player == null || player.target == null) return;
        if (player.target.interactAudio == null) return;
        player.target.PlayInteractSound();
    }

    public void questAudio()
    {
        Player player = Player.localPlayer;
        if (player == null || player.target == null) return;
        if (player.target.questAudio == null) return;
        player.target.PlayQuestAudio();
    }
}