using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skill System/Skill")]
public class SkillBase : ScriptableObject
{
    public string SkillName;
    public int activeTime;
    public float Cooldown;        
    public int ManaCost;           
    public Sprite Icon;            
    public GameObject EffectPrefab;

    private float lastUsedTime;

    public void Initialize()
    {
       
        lastUsedTime = Time.time - Cooldown; // kullanýlabilir baþlasýn
        
    }
    public bool IsReady()
    {
        return Time.time >= lastUsedTime + Cooldown;
    }
    

    // skill kullan
    public void Activate(GameObject player)
    {
        if (!IsReady())
        {
            Debug.Log($"{SkillName} is on cooldown! Remaining time: {Mathf.Max(0, (lastUsedTime + Cooldown) - Time.time)} seconds");
            return;
        }

        lastUsedTime = Time.time;

        // vfx oluþtur
        if (EffectPrefab != null)
        {
            GameObject effectInstance = Instantiate(EffectPrefab, player.transform.position, Quaternion.identity);
            effectInstance.transform.SetParent(player.transform);

            // activeTime sýfýrdan büyükse efekti kapat 
            if (activeTime > 0)
            {
                Destroy(effectInstance, activeTime);
            }

        }

        Debug.Log($"{SkillName} activated!");
    }
}
