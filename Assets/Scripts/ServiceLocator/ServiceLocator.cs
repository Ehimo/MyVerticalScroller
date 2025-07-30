using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    readonly Dictionary<string, IService> services = new();

    public static ServiceLocator Current { get; private set; }
    public static void Init()
    {
        Current = new();
    }

    public T Get<T>() where T : IService
    {
        var key = typeof(T).Name;
        if (!services.ContainsKey(key))
        {
            Debug.LogError("Ошибка при получении незарегестрированного сервиса.");
            throw new InvalidOperationException();
        }

        return (T)services[key];
    }

    public void Register<T>(T service) where T : IService
    {
        var key = typeof(T).Name;
        if (services.ContainsKey(key))
        {
            Debug.LogError($"Ошибка при регистрации сервиса по ключу {key} за которым уже зарегистрирован сервис");
            return;
        }

        services.Add(key, service);
    }

    public void UnRegister<T>() where T : IService
    {
        var key = typeof(T).Name;
        if (!services.ContainsKey(key))
        {
            Debug.LogError("Ошибка при попытке удалить сервис который не зарегестрирован");
            return;
        }

        services.Remove(key);
    }
}