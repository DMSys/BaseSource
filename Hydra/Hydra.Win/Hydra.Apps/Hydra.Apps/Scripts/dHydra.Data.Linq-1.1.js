function LinqConnection(database, connectionString) {
    // Database
    this.linqDatabase = database;
    // Connection string
    this.linqConnectionString = connectionString;
    // Connection id
    this.connectionId = "";

    /* Opens a connection to the database
    */
    this.Open = function () {
        this.connectionId = dHydraData.OpenConnection(this.toJson());
        return (this.connectionId != "");
    }
    /* Closes the connection to the database
    */
    this.Close = function () {
        dHydraData.CloseConnection(this.connectionId);
    }

    this.toJson = function () {
        return JSON.stringify({ 'database': this.linqDatabase, 'connection': this.linqConnectionString });
    }
}

var linqDatabase = {
    SQLite: 'sqlite',
    MSSql: 'mssql'
}

function LinqQuery(connection) {

    var linqConnection = connection;

    var linqCommand = {};

    this.select = function () {
        linqCommand.command = 'select';
        linqCommand.list = [];
        for (var i = 0; i < arguments.length; i++) {
            linqCommand.list.push(arguments[i].toSelectString());
        }
    }

    this.from = function () {
        linqCommand.from = [];
        for (var i = 0; i < arguments.length; i++) {
            var tableName = arguments[i]['_Name'];
            var tableAlias = arguments[i]['_Alias'];

            linqCommand.from.push({ 'name': tableName, 'alias': tableAlias });
        }
    }

    this.where = function () {
        linqCommand.where = [];
        for (var i = 0; i < arguments.length; i++) {
            linqCommand.where.push(arguments[i]);
        }
    }

    this.toJsonCommand = function () {
        return JSON.stringify(linqCommand);
    }

    /* Execute query
    */
    this.execute = function (connection) {
        var result = null;
        if (connection != null) {
            result = dHydraData.ExecuteQuery(this.toJsonCommand(), connection.connectionId);
        }
        else if (linqConnection != null) {
            result = dHydraData.ExecuteQuery(this.toJsonCommand(), linqConnection.connectionId);
        }
        else {
            throw Error('No connection.');
        }
        return JSON.parse(result);
    }
}
/* Table field
*/
function LinqTableField(fieldName, tableAlias) {
    this.name = fieldName;
    this.alias = tableAlias;
    this.text;

    this.As = function (fieldText) {
        this.text = fieldText;
        return this;
    }

    this.toSelectString = function () {
        return { 'name': this.name, 'alias': this.alias, 'text': this.text }
    }

    this.toFieldString = function () {
        return { 'name': this.name, 'alias': this.alias }
    }
}

var linqCondition = {
    /* = 
       Equality between two expressions
    */
    Equality: function (expr1, expr2) {
        return { 'condition': '=', 'expr1': expr1.toFieldString(), 'expr2': expr2.toFieldString() };
    }
    /*
     =

    Is the operator used to test the equality between two expressions.
<>

    Is the operator used to test the condition of two expressions not being equal to each other.
!=

    Is the operator used to test the condition of two expressions not being equal to each other.
> 

    Is the operator used to test the condition of one expression being greater than the other.
>= 

    Is the operator used to test the condition of one expression being greater than or equal to the other expression.
!>

    Is the operator used to test the condition of one expression not being greater than the other expression.
<

    Is the operator used to test the condition of one expression being less than the other.
<=

    Is the operator used to test the condition of one expression being less than or equal to the other expression.
!<

    Is the operator used to test the condition of one expression not being less than the other expression.
string_expression

    Is a string of characters and wildcard characters.
[ NOT ] LIKE

    Indicates that the subsequent character string is to be used with pattern matching. For more information, see LIKE (Transact-SQL).
ESCAPE 'escape_ character'

    Allows for a wildcard character to be searched for in a character string instead of functioning as a wildcard. escape_character is the character that is put in front of the wildcard character to indicate this special use.
[ NOT ] BETWEEN

    Specifies an inclusive range of values. Use AND to separate the starting and ending values. For more information, see BETWEEN (Transact-SQL).
IS [ NOT ] NULL

    Specifies a search for null values, or for values that are not null, depending on the keywords used. An expression with a bitwise or arithmetic operator evaluates to NULL if any one of the operands is NULL.
CONTAINS

    Searches columns that contain character-based data for precise or less precise (fuzzy) matches to single words and phrases, the proximity of words within a certain distance of one another, and weighted matches. This option can only be used with SELECT statements. For more information, see CONTAINS (Transact-SQL).
FREETEXT

    Provides a simple form of natural language query by searching columns that contain character-based data for values that match the meaning instead of the exact words in the predicate. This option can only be used with SELECT statements. For more information, see FREETEXT (Transact-SQL).
[ NOT ] IN

    Specifies the search for an expression, based on whether the expression is included in or excluded from a list. The search expression can be a constant or a column name, and the list can be a set of constants or, more typically, a subquery. Enclose the list of values in parentheses. For more information, see IN (Transact-SQL).
subquery

    Can be considered a restricted SELECT statement and is similar to <query_expresssion> in the SELECT statement. The ORDER BY clause and the INTO keyword are not allowed. For more information, see SELECT (Transact-SQL).
ALL

    Used with a comparison operator and a subquery. Returns TRUE for <predicate> when all values retrieved for the subquery satisfy the comparison operation, or FALSE when not all values satisfy the comparison or when the subquery returns no rows to the outer statement. For more information, see ALL (Transact-SQL).
{ SOME | ANY }

    Used with a comparison operator and a subquery. Returns TRUE for <predicate> when any value retrieved for the subquery satisfies the comparison operation, or FALSE when no values in the subquery satisfy the comparison or when the subquery returns no rows to the outer statement. Otherwise, the expression is UNKNOWN. For more information, see SOME | ANY (Transact-SQL).
EXISTS

    Used with a subquery to test for the existence of rows returned by the subquery. For more information, see EXISTS (Transact-SQL).

    */
}