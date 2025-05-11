﻿public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int AvailableCopies { get; set; }
    public int BorrowCount { get; set; } = 0; // NEW
}
