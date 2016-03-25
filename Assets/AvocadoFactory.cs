using System.Collections;

public class AvocadoFactory { 

    public static Avocado GenerateEnemy(int storyLevel)
    {
        // Some equation to calculate the enemy's level
        int level = storyLevel * 8 / 5 + 2;
        // Gonna need a way to generate all of the enemy's equipped cards
        Avocado avocado = new Avocado(storyLevel, 0, null, null, null, null, null, null);

        return avocado;
    }


}
