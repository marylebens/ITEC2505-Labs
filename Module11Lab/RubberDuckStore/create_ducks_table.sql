CREATE TABLE Ducks (
    Id INTEGER PRIMARY KEY,
    Name TEXT,
    Description TEXT,
    Price DECIMAL(10,2),
    ImageFileName TEXT
);

INSERT INTO Ducks (Name, Description, Price, ImageFileName) VALUES
('Classic Debugger', 'The original rubber duck for all your debugging needs', 9.99, 'classic_debugger.jpg'),
('Coder Duck', 'This duck comes with its own tiny laptop for pair programming', 14.99, 'coder_duck.jpg');
