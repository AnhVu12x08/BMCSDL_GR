-- Create a user BMCSDL_1 with password '123'
Create User Bmcsdl_1 Identified By 123;

-- Grant session creation privilege to BMCSDL_1, allowing them to connect to the database
grant create session to BMCSDL_1;

-- Grant the privilege to create tables to BMCSDL_1
grant create table to BMCSDL_1;

-- Set a quota of 100MB on the USERS tablespace for BMCSDL_1, limiting their data usage
alter user BMCSDL_1 quota 100M on users;

-- Remove user BMCSDL_1 and all of their objects
drop user BMCSDL_1 cascade;

-- Display all system privileges assigned to the user 'USERTEST2'
SELECT * FROM DBA_SYS_PRIVS WHERE GRANTEE = 'USERTEST2';

-- Grant additional privileges to BMCSDL_1
GRANT CREATE USER TO BMCSDL_1;          -- Allows user creation
GRANT CREATE TABLE TO BMCSDL_1;         -- Allows table creation
GRANT CONNECT TO BMCSDL_1;              -- Basic connection privilege
GRANT ALTER USER, DROP USER TO BMCSDL_1; -- Allows altering and dropping users
GRANT CREATE SESSION TO BMCSDL_1;       -- Allows session creation

-- Grant all system privileges to BMCSDL_1
GRANT ALL PRIVILEGES TO BMCSDL_1;

-- Select basic information from the DBA_USERS and ALL_USERS views
select * from dba_users;
select * from all_users;

-- Commit changes
commit;

-- Select all users from the ALL_USERS view
select * from all_users;

-- Select data from custom tables (assuming these tables exist in the schema)
Select * from nhanvien;
select * from nguoithue;
select * from phong;
select * from dat_phong;

-- Show user role privileges, table privileges, and system privileges
SELECT * FROM USER_ROLE_PRIVS;
SELECT * FROM USER_TAB_PRIVS;
SELECT * FROM USER_SYS_PRIVS;

-- Create PHONG table to store room details
CREATE TABLE PHONG
(
  MA_PHONG INT PRIMARY KEY,
  TEN_PHONG NVARCHAR2(255),
  TANG INT,
  SO_GIUONG INT,
  GIA FLOAT CHECK (GIA >= 0), -- Price must be non-negative
  TRANG_THAI NVARCHAR2(50)
);

-- Create NHANVIEN table to store employee information
CREATE TABLE NHANVIEN
(
  USERNAME NVARCHAR2(255),
  MA_NHANVIEN INT PRIMARY KEY,
  SDT_NV NVARCHAR2(12),
  EMAIL_NV VARCHAR(255),
  PW VARCHAR(255), -- Password column
  MA_KHACHSAN INT, -- Hotel ID (foreign key can be added later)
  MA_NV_QUANLY INT, -- Manager ID, references NHANVIEN table
  CONSTRAINT FK_NV_NV FOREIGN KEY (MA_NV_QUANLY) REFERENCES NHANVIEN(MA_NHANVIEN)
);

-- Create NGUOITHUE table to store tenant information
CREATE TABLE NGUOITHUE
(
  MA_NGUOITHUE INT PRIMARY KEY,
  HOTEN_NT NVARCHAR2(255),
  SDT NVARCHAR2(12),
  EMAIL VARCHAR(255)
);

-- Create DATPHONG table to store booking information, with foreign keys for room, tenant, and employee
CREATE TABLE DATPHONG 
(
  MA_DATPHONG INT PRIMARY KEY,
  NGAY_VAO DATE,
  NGAY_RA DATE,
  MA_PHONG INT,
  MA_NGUOITHUE INT,
  MA_NHANVIEN INT,
  CONSTRAINT FK_DP_PH FOREIGN KEY (MA_PHONG) REFERENCES PHONG(MA_PHONG),
  CONSTRAINT FK_DP_NT FOREIGN KEY (MA_NGUOITHUE) REFERENCES NGUOITHUE(MA_NGUOITHUE),
  CONSTRAINT FK_DP_NV FOREIGN KEY (MA_NHANVIEN) REFERENCES NHANVIEN(MA_NHANVIEN)
);

-- Create a sequence for NHANVIEN table
CREATE SEQUENCE nhanvien_seq START WITH 1 INCREMENT BY 1;

-- Insert sample data into the PHONG table
INSERT ALL 
INTO PHONG (MA_PHONG, TEN_PHONG, TANG, SO_GIUONG, GIA, TRANG_THAI) VALUES (101, 'Deluxe Room', 1, 2, 500.00, 'Available')
INTO PHONG (MA_PHONG, TEN_PHONG, TANG, SO_GIUONG, GIA, TRANG_THAI) VALUES (102, 'Standard Room', 1, 1, 300.00, 'Occupied')
INTO PHONG (MA_PHONG, TEN_PHONG, TANG, SO_GIUONG, GIA, TRANG_THAI) VALUES (201, 'Suite', 2, 3, 800.00, 'Available')
INTO PHONG (MA_PHONG, TEN_PHONG, TANG, SO_GIUONG, GIA, TRANG_THAI) VALUES (202, 'Family Room', 2, 4, 650.00, 'Under Maintenance')
INTO PHONG (MA_PHONG, TEN_PHONG, TANG, SO_GIUONG, GIA, TRANG_THAI) VALUES (301, 'Luxury Suite', 3, 2, 1000.00, 'Available')
SELECT * FROM DUAL;

-- Insert sample data into the NGUOITHUE table
INSERT ALL 
INTO NGUOITHUE (MA_NGUOITHUE, HOTEN_NT, SDT, EMAIL) VALUES (1, 'Nguyen Van A', '0934123456', 'nguyenvana@example.com')
INTO NGUOITHUE (MA_NGUOITHUE, HOTEN_NT, SDT, EMAIL) VALUES (2, 'Tran Thi B', '0912345678', 'tranthib@example.com')
INTO NGUOITHUE (MA_NGUOITHUE, HOTEN_NT, SDT, EMAIL) VALUES (3, 'Le Minh C', '0923456789', 'leminhc@example.com')
INTO NGUOITHUE (MA_NGUOITHUE, HOTEN_NT, SDT, EMAIL) VALUES (4, 'Hoang Dung D', '0945123456', 'hoangdungd@example.com')
SELECT * FROM DUAL;

-- Query data from the custom tables
SELECT * FROM PHONG;
SELECT * FROM NHANVIEN;
SELECT * FROM NGUOITHUE;
SELECT * FROM DATPHONG;

-- Create procedures for encrypting and decrypting passwords using AES256 encryption
CREATE OR REPLACE PROCEDURE ENCRYPT_PW (
    p_plaintext IN VARCHAR2,    -- Input plaintext password
    p_key       IN VARCHAR2,    -- Encryption key
    p_ciphertext OUT RAW        -- Output encrypted password
) AS
BEGIN
    p_ciphertext := DBMS_CRYPTO.ENCRYPT(
                        src => UTL_I18N.STRING_TO_RAW(p_plaintext, 'AL32UTF8'),
                        typ => DBMS_CRYPTO.ENCRYPT_AES256 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
                        key => UTL_I18N.STRING_TO_RAW(p_key, 'AL32UTF8')        
                    );
END;
/

CREATE OR REPLACE PROCEDURE DECRYPT_PW (
    p_ciphertext IN RAW,          -- Input encrypted password
    p_key        IN VARCHAR2,     -- Decryption key
    p_plaintext  OUT VARCHAR2     -- Output decrypted plaintext password
) AS
    v_decrypted_raw RAW(32767);
BEGIN
    v_decrypted_raw := DBMS_CRYPTO.DECRYPT(
                           src => p_ciphertext,
                           typ => DBMS_CRYPTO.ENCRYPT_AES256 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
                           key => UTL_I18N.STRING_TO_RAW(p_key, 'AL32UTF8')
                       );

    p_plaintext := UTL_I18N.RAW_TO_CHAR(v_decrypted_raw, 'AL32UTF8');
END;
/

-- Select user information from all users
SELECT USERNAME FROM ALL_USERS;

-- Retrieve usernames from the USERS table (if it exists)
SELECT username FROM users;
