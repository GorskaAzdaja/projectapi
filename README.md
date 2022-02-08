Test task remade without using the repository pattern.

Used with SQL Server, and seeded the database with test data.

Relationship is set up as One to Many Project -> Task and works.

Known issue - The API returns an empty list when running get all Projects, but shows the project the tasks belong in when querying Tasks.
