delete todos
DBCC CHECKIDENT ('todos', RESEED, 0);

delete priorities
DBCC CHECKIDENT ('priorities', RESEED, 0);

delete categories
DBCC CHECKIDENT ('categories', RESEED, 0);

delete users
DBCC CHECKIDENT ('users', RESEED, 0);

