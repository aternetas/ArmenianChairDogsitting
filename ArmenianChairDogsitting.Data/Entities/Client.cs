﻿namespace ArmenianChairDogsitting.Data.Entities;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName  { get; set; }
    //public List<Animal> Dogs { get; set; } //раскомментировать после добавления animal в entities
}
