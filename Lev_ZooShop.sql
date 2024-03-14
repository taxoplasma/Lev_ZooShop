PGDMP     !                    |            Lev_ZooShop    14.6    14.6     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    18213    Lev_ZooShop    DATABASE     j   CREATE DATABASE "Lev_ZooShop" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "Lev_ZooShop";
                postgres    false            �            1259    18214    category    TABLE     m   CREATE TABLE public.category (
    category_id integer NOT NULL,
    name character varying(150) NOT NULL
);
    DROP TABLE public.category;
       public         heap    postgres    false            �            1259    18217    items    TABLE     �   CREATE TABLE public.items (
    item_id integer NOT NULL,
    name character varying NOT NULL,
    quantity integer NOT NULL,
    price money NOT NULL,
    description text NOT NULL,
    category_id integer
);
    DROP TABLE public.items;
       public         heap    postgres    false            �            1259    18222    users    TABLE     �   CREATE TABLE public.users (
    user_id integer NOT NULL,
    login character varying(50) NOT NULL,
    password character varying(50) NOT NULL,
    role character varying(50) NOT NULL
);
    DROP TABLE public.users;
       public         heap    postgres    false            �          0    18214    category 
   TABLE DATA           5   COPY public.category (category_id, name) FROM stdin;
    public          postgres    false    209   k       �          0    18217    items 
   TABLE DATA           Y   COPY public.items (item_id, name, quantity, price, description, category_id) FROM stdin;
    public          postgres    false    210   �       �          0    18222    users 
   TABLE DATA           ?   COPY public.users (user_id, login, password, role) FROM stdin;
    public          postgres    false    211   �       d           2606    18226    category category_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public.category
    ADD CONSTRAINT category_pkey PRIMARY KEY (category_id);
 @   ALTER TABLE ONLY public.category DROP CONSTRAINT category_pkey;
       public            postgres    false    209            f           2606    18228    items items_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.items
    ADD CONSTRAINT items_pkey PRIMARY KEY (item_id);
 :   ALTER TABLE ONLY public.items DROP CONSTRAINT items_pkey;
       public            postgres    false    210            h           2606    18230    users users_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    211            i           2606    18231    items fk_category_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.items
    ADD CONSTRAINT fk_category_id FOREIGN KEY (category_id) REFERENCES public.category(category_id);
 >   ALTER TABLE ONLY public.items DROP CONSTRAINT fk_category_id;
       public          postgres    false    209    3172    210            �   W   x�3ἰ�b���v]�pa�1����/6_�2⼰��>��P5��f]�w��5�pa���.츰���@�=... L7I      �   �   x�ePKN�0]�O�TȎ�n��qU ��K�D �T��	�܈Iڄ�H���y�Kx���0���}OxG��:~ƏF;Oe*#�y���7��l�ĥPWY�V�W�@��F���pS��U�'Q�d����΂��?ȏvd/��\�CMN�����dr罙�܍_��>%2Q��1]�J�j*h�l5ᓋlﯽ:� Hm?�^��`�փ:
)7��@.��f�����p���@�_      �   N   x�3�LL��̃�&\�raυ�^�q��b�ņ.6]�w��ˈ371/1=����0��V�ҭ@M�.l*����� ��*     