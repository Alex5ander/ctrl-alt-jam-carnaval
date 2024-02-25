using System;
using UnityEngine;
[CreateAssetMenu]
public class Mission : ScriptableObject
{
    public string Title;
    [TextArea]
    public string Description;
    public Action<Mission> Listener;
    public bool Completed = false;
}

// 1
// Pegue o balde de tinta e pinte as 3 paredes demarcadas no mapa. 
// Seja criativo e transforme Greenville em uma galeria de arte a céu aberto!

// 2
// É hora da festa do lixo! Derrube 5 lixeiras e espalhe a bagunça pela cidade. 
// Vamos causar o caos e deixar a sujeira falar.

// 3
// Cheiro de encrenca no ar! Colete ovos podres e lance-os na praça central de Greenville. 
// Prepare-se para fazer as pessoas torcerem o nariz e correr.

// 4
// Encontre e quebre 5 hidrantes pela cidade. 
// Vamos transformar Greenville em uma festa aquática bem diferente.

// 5
// Fogo no parquinho? Dispare o alarme de incêndio para criar o caos em Greenville. 
// Hora de causar uma confusão épica e sair correndo antes que as autoridades cheguem!