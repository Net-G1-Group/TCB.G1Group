create schema if not exists public;

create table users
(
    id serial PRIMARY KEY,
    telegram_client_id bigint,
    password           varchar(24),
    phone_number       varchar(13)
);


create table clients
(
    id serial PRIMARY KEY,
    user_id          bigint,
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
    from_id     bigint,
    to_id       bigint,
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
    owner_id bigint,
    board_status bigint,
    FOREIGN KEY (owner_id)
        REFERENCES clients (id)
);


create table messages
(
    id       serial PRIMARY key,
    from_id  bigint,
    message  text,
    chat_id  bigint,
    message_type     bigint,
    board_id bigint,
    FOREIGN KEY (from_id)
        REFERENCES clients (id),
    FOREIGN KEY (board_id)
        REFERENCES boards (id)
);