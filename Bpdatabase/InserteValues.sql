-- Users
INSERT INTO Users (UserId, Username, Email, PasswordHash, Currency, DefaultCategoryId)
VALUES 
('11111111-1111-1111-1111-111111111111', 'alice', 'alice@example.com', 'hashed_pw1', 'SEK', 'aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa'),
('22222222-2222-2222-2222-222222222222', 'bob', 'bob@example.com', 'hashed_pw2', 'USD', NULL),
('33333333-3333-3333-3333-333333333333', 'charlie', 'charlie@example.com', 'hashed_pw3', 'EUR', NULL);

-- Categories
INSERT INTO Categories (CategoryId, UserId, Name)
VALUES
('aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '11111111-1111-1111-1111-111111111111', 'Food'),
('aaaaaaa2-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '11111111-1111-1111-1111-111111111111', 'Salary'),
('bbbbbbb1-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '22222222-2222-2222-2222-222222222222', 'Entertainment');

-- Transactions
INSERT INTO Transactions (TransactionId, UserId, Amount, Description, Date, CategoryId, Type)
VALUES
('11111111-aaaa-bbbb-cccc-111111111111', '11111111-1111-1111-1111-111111111111', 100.00, 'Grocery shopping', GETDATE(), 'aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Expense'),
('22222222-aaaa-bbbb-cccc-222222222222', '11111111-1111-1111-1111-111111111111', 25000.00, 'Monthly salary', GETDATE(), 'aaaaaaa2-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Income'),
('33333333-aaaa-bbbb-cccc-333333333333', '22222222-2222-2222-2222-222222222222', 300.00, 'Movie tickets', GETDATE(), 'bbbbbbb1-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'Expense');
