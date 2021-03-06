// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System;

// UCE_HonorShopCurrencyDrop

[Serializable]
public partial struct UCE_HonorShopCurrencyDrop
{
    public UCE_Tmpl_HonorCurrency honorCurrency;
    public long amountMin;
    public long amountMax;

    public long amount
    {
        get
        {
            return (long)UnityEngine.Random.Range(amountMin, amountMax);
        }
    }
}
