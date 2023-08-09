create schema if not exists public;

create table users
(
    id serial PRIMARY KEY,
    telegram_client_id int,
    password           varchar(24),
    phone_number       varchar(13)
);


create table clients
(
    id serial PRIMARY KEY,
    user_id          int,
    telegram_chat_id int,
    nickname         varchar(30),
    is_premium       bool,
    status           int,
    FOREIGN KEY (user_id)
        references users (id)
);

create table anonym_chats
(
    id          serial PRIMARY key,
    create_date date,
    from_id     int,
    to_id       int,
    state       int,
    FOREIGN KEY (from_id)
        REFERENCES clients (id),
    FOREIGN KEY (to_id)
        REFERENCES clients (id)
);


create table boards
(
    id       serial PRIMARY KEY,
    nickname varchar(30),
    owner_id int,
    board_status int,
    FOREIGN KEY (owner_id)
        REFERENCES clients (id)
);


create table messages
(
    id       serial PRIMARY key,
    from_id  int,
    message  text,
    chat_id  int,
    type     int,
    board_id int,
    FOREIGN KEY (from_id)
        REFERENCES clients (id),
    FOREIGN KEY (board_id)
        REFERENCES boards (id)
);