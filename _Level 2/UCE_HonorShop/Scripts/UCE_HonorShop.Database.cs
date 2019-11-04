// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
#if _MYSQL
using MySql.Data;								// From MySql.Data.dll in Plugins folder
using MySql.Data.MySqlClient;                   // From MySql.Data.dll in Plugins folder
#elif _SQLITE

using SQLite; 						// copied from Unity/Mono/lib/mono/2.0 to Plugins

#endif

// DATABASE (SQLite / mySQL Hybrid)

public partial class Database
{
    // -----------------------------------------------------------------------------------
    // Connect_UCE_HonorShop
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Connect")]
    private void Connect_UCE_HonorShop()
    {
#if _MYSQL
		ExecuteNonQueryMySql(@"CREATE TABLE IF NOT EXISTS character_currencies (
			`character` VARCHAR(32) NOT NULL,
			currency VARCHAR(32) NOT NULL,
			amount INTEGER(16) NOT NULL,
			total INTEGER(16) NOT NULL
		    )CHARACTER SET=utf8mb4");
#elif _SQLITE
        connection.CreateTable<character_currencies>();
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterLoad_UCE_HonorShop
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterLoad")]
    private void CharacterLoad_UCE_HonorShop(Player player)
    {
#if _MYSQL
		var table = ExecuteReaderMySql("SELECT currency, amount, total FROM character_currencies WHERE `character`=@name", new MySqlParameter("@name", player.name));
        foreach (var row in table)
        {
            string tmplName = (string)row[0];
            UCE_Tmpl_HonorCurrency tmplCurrency;

            if (UCE_Tmpl_HonorCurrency.dict.TryGetValue(tmplName.GetStableHashCode(), out tmplCurrency))
            {
                UCE_HonorShopCurrency hsc = new UCE_HonorShopCurrency();
                hsc.honorCurrency = tmplCurrency;
                hsc.amount = (int)row[1];
                hsc.total = (int)row[2];
                player.UCE_currencies.Add(hsc);
            }
        }
#elif _SQLITE
        var table = connection.Query<character_currencies>("SELECT currency, amount, total FROM character_currencies WHERE character=?", player.name);
        foreach (var row in table)
        {
            string tmplName = row.currency;
            UCE_Tmpl_HonorCurrency tmplCurrency;

            if (UCE_Tmpl_HonorCurrency.dict.TryGetValue(tmplName.GetStableHashCode(), out tmplCurrency))
            {
                UCE_HonorShopCurrency hsc = new UCE_HonorShopCurrency();
                hsc.honorCurrency = tmplCurrency;
                hsc.amount = row.amount;
                hsc.total = row.total;
                player.UCE_currencies.Add(hsc);
            }
        }
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterSave_UCE_HonorShop
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterSave")]
    private void CharacterSave_UCE_HonorShop(Player player)
    {
#if _MYSQL
		ExecuteNonQueryMySql("DELETE FROM character_currencies WHERE `character`=@character", new MySqlParameter("@character", player.name));
        for (int i = 0; i < player.UCE_currencies.Count; ++i)
        {
            ExecuteNonQueryMySql("INSERT INTO character_currencies VALUES (@character, @currency, @amount, @total)",
                 new MySqlParameter("@character", player.name),
                 new MySqlParameter("@currency", player.UCE_currencies[i].honorCurrency.name),
                 new MySqlParameter("@amount", player.UCE_currencies[i].amount),
                 new MySqlParameter("@total", player.UCE_currencies[i].total)
                 );
        }
#elif _SQLITE
        connection.Execute("DELETE FROM character_currencies WHERE character=?", player.name);
        for (int i = 0; i < player.UCE_currencies.Count; ++i)
            connection.InsertOrReplace(new character_currencies
            {
                character = player.name,
                currency = player.UCE_currencies[i].honorCurrency.name,
                amount = player.UCE_currencies[i].amount,
                total = player.UCE_currencies[i].total
            });
#endif
    }

    // -----------------------------------------------------------------------------------
}
