# Zombie-Horror
In Progress
<div style="display: flex; justify-content: space-between;">
  <img src="https://github.com/Calvinking2/Zombie-Horror/assets/54987031/091ab58c-bc6b-4f37-922d-22d4ec2d03a4" alt="Image 1" width="45%">
  <img src="https://github.com/Calvinking2/Zombie-Horror/assets/54987031/9ee7212e-d68c-4b52-8f68-680c2e238766" alt="Image 2" width="45%">
  <img src="https://github.com/Calvinking2/Zombie-Horror/assets/54987031/9b659803-64a2-4d1e-a1a1-91befd4af81f" width="45%">
</div>


- **Tutorial use on game:** [HOW TO MAKE A SURVIVAL HORROR GAME IN UNITY](https://www.youtube.com/playlist?list=PLZ1b66Z1KFKiaTYwyayb8-L7D6bdiaHzc)
## About the Game Project 

This is a Zombie Survival game where you are trapped in a cellar and now have to find a way out in this dangerous place and more importantly Survive

#### Game controls

The following controls are bound in-game, for gameplay and testing.

note : Key Binding are subject to change

| Key Binding       | Function          |
| ----------------- | ----------------- |
| W,A,S,D           | Standard movement |
| Space             | Jump              |
| Left Click        | Fire              |
| E                  | Interect         |

## Script
 - **Movement**   : [Unity Standard Asset](https://github.com/Unity-Technologies/Standard-Assets-Characters) 
 - **Zombie AI**  :

```C#
public class ZombieAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public Animator zombieAnimator;
    public float enemySpeeed = 0.01f;
    public bool attackTrigger = false;
    public bool isAttacking = false;

    void Update()
    {
        transform.LookAt(Player.transform);
        if(attackTrigger == false)
        {
            enemySpeeed= 0.01f;
            zombieAnimator.SetTrigger("Walk");
            transform.position = Vector3.MoveTowards(transform.position,Player.transform.position,enemySpeeed);
        }
        if(attackTrigger == true && isAttacking == false) 
        {
            Debug.Log("Atack");
            enemySpeeed = 0;
            zombieAnimator.SetTrigger("Attack");
            StartCoroutine(InflictDamage());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        attackTrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        attackTrigger = false;
    }
    IEnumerator InflictDamage()
    {
        isAttacking= true;
        yield return new WaitForSeconds(1.1f);
        GlobalHealth.currentHealth -= 5;
        yield return new WaitForSeconds(0.2f);
        isAttacking= false;
    }
```
**This is a brief explanation of the Zombie AI**
```c#
 void Update()
    {
        transform.LookAt(Player.transform);
        if(attackTrigger == false)
        {
            enemySpeeed= 0.01f;
            zombieAnimator.SetTrigger("Walk");
            transform.position = Vector3.MoveTowards(transform.position,Player.transform.position,enemySpeeed);
        }
        if(attackTrigger == true && isAttacking == false) 
        {
            Debug.Log("Atack");
            enemySpeeed = 0;
            zombieAnimator.SetTrigger("Attack");
            StartCoroutine(InflictDamage());
        }
    }
```
This Code indicate that the zombie on default will only do Walk animation but when the zombie enter player attack hit box
then the zombie will do Attack animation
```c#
void OnTriggerEnter(Collider other)
    {
        attackTrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        attackTrigger = false;
    }
```
After the zombie do attack animation and hit the player then the player health will decrease with ```StartCoroutine(InflictDamage());```
```c#
 IEnumerator InflictDamage()
    {
        isAttacking= true;
        yield return new WaitForSeconds(1.1f);
        GlobalHealth.currentHealth -= 5;
        yield return new WaitForSeconds(0.2f);
        isAttacking= false;
    }
```
