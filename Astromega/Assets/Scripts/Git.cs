using UnityEngine;

public class Git : MonoBehaviour
{
    public Animator animator;
    public string githubURL = "https://github.com/";

    public void PlayAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Play"); // make sure you have a Trigger named "Play"
        }
    }

    public void OpenGitHub()
    {
        Application.OpenURL(githubURL);
    }
}