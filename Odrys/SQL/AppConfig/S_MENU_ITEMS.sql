/*
Navicat SQLite Data Transfer

Source Server         : Odrys_AppConfig
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2013-07-02 21:11:57
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for S_MENU_ITEMS
-- ----------------------------
DROP TABLE IF EXISTS "main"."S_MENU_ITEMS";
CREATE TABLE "S_MENU_ITEMS" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"PARENT_ID"  INTEGER,
"MENU_ID"  INTEGER,
"MENU_ITEM_TYPE_ID"  INTEGER,
"ITEM_TEXT"  TEXT,
"ITEM_VALUE"  TEXT,
"ORDER_NO"  INTEGER,
"LINK_AREA"  TEXT,
"LINK_CONTROLLER"  TEXT,
"LINK_ACTION"  TEXT,
"S_PAGE_ID"  INTEGER,
CONSTRAINT "FK_MENU_ID" FOREIGN KEY ("MENU_ID") REFERENCES "S_MENUS" ("ID")
);
