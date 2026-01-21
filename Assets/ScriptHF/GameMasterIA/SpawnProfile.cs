[System.Serializable]
public class SpawnProfile
{
    public int weaponCount;
    public int ammoCount;
    public int enemyCount;

    public SpawnProfile(int weapons, int ammo, int enemies)
    {
        weaponCount = weapons;
        ammoCount = ammo;
        enemyCount = enemies;
    }
}
