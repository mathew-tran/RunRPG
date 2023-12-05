using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MessageBoxSystem : MonoBehaviour
{

    public List<string> mMessageList;

    public int mMaxMessageCapacity = 10;

    public Color mUseColor;
    public Color mUnusedColor;
    public bool mHasNewMessage = false;

    public float mMaxTime = 10.0f;
    public float mCurrentTime = 0.0f;

    private float mAlphaDecayRate = .002f;

    private Text mTextReference;

    public Queue<string> mTexts;

    // Use this for initialization
    void Start()
    {
        mTexts = new Queue<string>();
        mTextReference = GameObject.Find("EventMessageText").GetComponent<Text>();
        mTextReference.text = "";
    }

    public void addMessage(string message)
    {
        if (mTextReference)
        {
            mTexts.Enqueue(message);
            StartCoroutine("AddMessage", 0.4f * mTexts.Count);
        }
    }
    IEnumerator AddMessage(float time)
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        if (mTexts.Count != 0)
        {
            mMessageList.Add(mTexts.Dequeue());
            setClock();
            mTextReference.color = mUseColor;
            manageMessages();
        }
    }
    private void manageMessages()
    {
        if (mMessageList.Count > mMaxMessageCapacity)
        {
            mMessageList.RemoveAt(0);
        }
        mTextReference.text = "";
        foreach (string message in mMessageList)
        {
            mTextReference.text += message + "\n";
        }
    }

    private void setClock()
    {
        mCurrentTime = mMaxTime;
    }
    private void RunClock()
    {
        if (mCurrentTime >= 0)
        {
            mCurrentTime -= Time.deltaTime;
            Color colorRef = mTextReference.color;
            mTextReference.color = new Color(colorRef.r, colorRef.g, colorRef.b, colorRef.a - mAlphaDecayRate);
        }
        else
        {
            mHasNewMessage = false;
            mTextReference.color = mUnusedColor;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (mHasNewMessage)
        {
            RunClock();
        }

        if (!GameHelper.IsPlayerAlive() || !GameHelper.IsGamePlaying())
        {
            mTextReference.color = mUseColor;
        }
    }
}
