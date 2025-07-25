PGDMP      8                }         	   Ecommerce    17.5    17.5     (           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            )           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            *           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            +           1262    16388 	   Ecommerce    DATABASE     ~   CREATE DATABASE "Ecommerce" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';
    DROP DATABASE "Ecommerce";
                     postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                     pg_database_owner    false            ,           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                        pg_database_owner    false    4            �            1259    16437    order_items    TABLE     �   CREATE TABLE public.order_items (
    item_id integer NOT NULL,
    order_id integer,
    product_name text NOT NULL,
    quantity integer NOT NULL,
    state text
);
    DROP TABLE public.order_items;
       public         heap r       postgres    false    4            �            1259    16436    order_items_item_id_seq    SEQUENCE     �   CREATE SEQUENCE public.order_items_item_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.order_items_item_id_seq;
       public               postgres    false    220    4            -           0    0    order_items_item_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.order_items_item_id_seq OWNED BY public.order_items.item_id;
          public               postgres    false    219            �            1259    16429    orders    TABLE     V   CREATE TABLE public.orders (
    order_id integer NOT NULL,
    customer_name text
);
    DROP TABLE public.orders;
       public         heap r       postgres    false    4            �            1259    16428    orders_order_id_seq    SEQUENCE     �   ALTER TABLE public.orders ALTER COLUMN order_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.orders_order_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public               postgres    false    218    4            �           2604    16440    order_items item_id    DEFAULT     z   ALTER TABLE ONLY public.order_items ALTER COLUMN item_id SET DEFAULT nextval('public.order_items_item_id_seq'::regclass);
 B   ALTER TABLE public.order_items ALTER COLUMN item_id DROP DEFAULT;
       public               postgres    false    220    219    220            %          0    16437    order_items 
   TABLE DATA                 public               postgres    false    220   `       #          0    16429    orders 
   TABLE DATA                 public               postgres    false    218   (       .           0    0    order_items_item_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.order_items_item_id_seq', 22, true);
          public               postgres    false    219            /           0    0    orders_order_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.orders_order_id_seq', 10, true);
          public               postgres    false    217            �           2606    16444    order_items order_items_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public.order_items
    ADD CONSTRAINT order_items_pkey PRIMARY KEY (item_id);
 F   ALTER TABLE ONLY public.order_items DROP CONSTRAINT order_items_pkey;
       public                 postgres    false    220            �           2606    16435    orders orders_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_pkey PRIMARY KEY (order_id);
 <   ALTER TABLE ONLY public.orders DROP CONSTRAINT orders_pkey;
       public                 postgres    false    218            �           2606    16445 %   order_items order_items_order_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.order_items
    ADD CONSTRAINT order_items_order_id_fkey FOREIGN KEY (order_id) REFERENCES public.orders(order_id);
 O   ALTER TABLE ONLY public.order_items DROP CONSTRAINT order_items_order_id_fkey;
       public               postgres    false    220    4749    218            %   �   x����
�@��>��Va�4��S��*i]eՉt�u6��[a_����������%$i��h�N6�A��+I�O�ϫ�-��k�Ck�����E�>&���[\�n9�80�?�����b��K~���e�e
��L��p��T�B*�(�� G��Qt=¹���ۖ��%����}�à�      #   q   x���v
Q���W((M��L��/JI-*V� ��):
ɥ�%��@N^bn����kP������Bpdp���B��O�+�Vа�QPwI,�LQ״���@�s3K2@6pq e�<�     