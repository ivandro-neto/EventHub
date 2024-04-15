## Tabelas:

### Accounts
| Coluna         | Tipo                | Restrições            | Comentários / Informações Extras |
|----------------|---------------------|-----------------------|----------------------------------|
| AccountID      | UNIQUEIDENTIFIER    | PRIMARY KEY, DEFAULT NEWID() | Identificador único da conta. |
| Username       | NVARCHAR(50)        | UNIQUE                | Nome de usuário único. |
| PasswordHash   | NVARCHAR(255)       |                       | Hash da senha do usuário. **Obs.:** Depreciado. |
| FirstName      | NVARCHAR(50)        |                       | Primeiro nome do titular da conta. |
| LastName       | NVARCHAR(50)        |                       | Último nome do titular da conta. |
| Email          | NVARCHAR(255)       |                       | Endereço de e-mail do titular da conta. |
| RegistrationDate | DATETIME           | DEFAULT GETDATE()     | Data de registro da conta. |

### Events
| Coluna         | Tipo                | Restrições            | Comentários / Informações Extras |
|----------------|---------------------|-----------------------|----------------------------------|
| EventID        | UNIQUEIDENTIFIER    | PRIMARY KEY, DEFAULT NEWID() | Identificador único do evento. |
| Name           | NVARCHAR(255)       |                       | Nome do evento. |
| Description    | NVARCHAR(MAX)       |                       | Descrição detalhada do evento. |
| StartDateTime  | DATETIME            |                       | Data e hora de início do evento. |
| EndDateTime    | DATETIME            |                       | Data e hora de término do evento. |
| Location       | NVARCHAR(255)       |                       | Localização do evento. |
| Type           | NVARCHAR(50)        |                       | Tipo do evento (Online ou Presencial). |
| Price          | DECIMAL(10, 2)      |                       | Preço do evento (para eventos pagos). |
| Capacity       | INT                 |                       | Capacidade máxima de participantes do evento. |
| Status         | NVARCHAR(50)        |                       | Status do evento (Ativo, Cancelado, etc.). |
| CreatorID      | UNIQUEIDENTIFIER    | FOREIGN KEY (Accounts(AccountID)) | Identificador único do criador do evento. |

### Attendees
| Coluna         | Tipo                | Restrições            | Comentários / Informações Extras |
|----------------|---------------------|-----------------------|----------------------------------|
| AttendeeID     | UNIQUEIDENTIFIER    | PRIMARY KEY, DEFAULT NEWID() | Identificador único do participante. |
| AccountID      | UNIQUEIDENTIFIER    | FOREIGN KEY (Accounts(AccountID)) | Identificador único da conta do participante. |
| Name           | NVARCHAR(255)       |                       | Nome do participante. |
| Email          | NVARCHAR(255)       |                       | Endereço de e-mail do participante. |
| BirthDate      | DATE                |                       | Data de nascimento do participante. |
| Gender         | NVARCHAR(10)        |                       | Gênero do participante. |
| Address        | NVARCHAR(255)       |                       | Endereço do participante. |
| ContactInfo    | NVARCHAR(255)       |                       | Informações de contato do participante. |
| AccountType    | NVARCHAR(50)        |                       | Tipo de conta do participante. |

### CheckIns
| Coluna         | Tipo                | Restrições            | Comentários / Informações Extras |
|----------------|---------------------|-----------------------|----------------------------------|
| CheckInID      | UNIQUEIDENTIFIER    | PRIMARY KEY, DEFAULT NEWID() | Identificador único do check-in. |
| EventID        | UNIQUEIDENTIFIER    | FOREIGN KEY (Events(EventID)) | Identificador único do evento associado ao check-in. |
| AttendeeID     | UNIQUEIDENTIFIER    | FOREIGN KEY (Attendees(AttendeeID)) | Identificador único do participante associado ao check-in. |
| State          | NVARCHAR(50)        |                       | Estado do check-in (Realizado, Não realizado, etc.). |
| CheckInDateTime | DATETIME           |                       | Data e hora do check-in. |

### Categories
| Coluna         | Tipo                | Restrições            | Comentários / Informações Extras |
|----------------|---------------------|-----------------------|----------------------------------|
| CategoryID     | UNIQUEIDENTIFIER    | PRIMARY KEY, DEFAULT NEWID() | Identificador único da categoria. |
| Name           | NVARCHAR(100)       |                       | Nome da categoria. |
| Description    | NVARCHAR(MAX)       |                       | Descrição da categoria. |

### EventsCategory
| Coluna         | Tipo                | Restrições            | Comentários / Informações Extras |
|----------------|---------------------|-----------------------|----------------------------------|
| EventCategoryID | UNIQUEIDENTIFIER   | PRIMARY KEY, DEFAULT NEWID() | Identificador único da relação entre evento e categoria. |
| EventID        | UNIQUEIDENTIFIER    | FOREIGN KEY (Events(EventID)) | Identificador único do evento associado à relação. |
| CategoryID     | UNIQUEIDENTIFIER    | FOREIGN KEY (Categories(CategoryID)) | Identificador único da categoria associada à relação. |
