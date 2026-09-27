using System;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

// Reflection keeps tests separate without moving existing scripts to an assembly
// or changing the scene and prefab script references.
public class LightSystemTests
{
    private GameObject player;
    private Component system;
    private Type type;

    [SetUp]
    public void SetUp()
    {
        type = Type.GetType("LightSystem, Assembly-CSharp", true);
        player = new GameObject("TestPlayer");
        system = player.AddComponent(type);
        Set("totalTime", 20f);
        Invoke("Start");
    }

    [TearDown]
    public void TearDown()
    {
        UnityEngine.Object.DestroyImmediate(player);
        Time.timeScale = 1f;
    }

    [Test]
    public void DamageUpdatesTimeWithoutOptionalUI()
    {
        Invoke("TakeDamage", 5f);
        Assert.AreEqual(15f, Get("totalTime"));
        Assert.AreEqual(15f, Get("currentTime"));
        Assert.AreEqual(15f, Get("intencidade"));
    }

    [Test]
    public void LethalDamageStopsGameAndClampsAtZero()
    {
        Invoke("TakeDamage", 50f);
        Assert.AreEqual(0f, Get("totalTime"));
        Assert.IsTrue((bool)type.GetProperty("IsGameOver").GetValue(system, null));
        Assert.AreEqual(0f, Time.timeScale);
    }

    [Test]
    public void NegativeDamageDoesNotHeal()
    {
        Invoke("TakeDamage", -10f);
        Assert.AreEqual(20f, Get("totalTime"));
    }

    [Test]
    public void PauseRejectsDamageAndCanResume()
    {
        Invoke("SetPaused", true);
        Invoke("TakeDamage", 10f);
        Assert.AreEqual(20f, Get("totalTime"));
        Assert.AreEqual(0f, Time.timeScale);
        Invoke("SetPaused", false);
        Invoke("TakeDamage", 5f);
        Assert.AreEqual(15f, Get("totalTime"));
        Assert.AreEqual(1f, Time.timeScale);
    }

    [Test]
    public void RefreshClampsToMaximum()
    {
        Set("totalTime", 100f);
        Invoke("Refresh");
        Assert.AreEqual(30f, Get("totalTime"));
        Assert.AreEqual(30f, Get("intencidade"));
    }

    private void Set(string field, float value) { type.GetField(field).SetValue(system, value); }
    private float Get(string field) { return (float)type.GetField(field).GetValue(system); }
    private void Invoke(string method, params object[] args)
    {
        type.GetMethod(method, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Invoke(system, args);
    }
}
