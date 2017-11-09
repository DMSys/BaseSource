/*
Navicat SQLite Data Transfer

Source Server         : Odrys_AppConfig
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2013-07-02 21:11:45
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for S_MENU_ITEM_TYPES
-- ----------------------------
DROP TABLE IF EXISTS "main"."S_MENU_ITEM_TYPES";
CREATE TABLE "S_MENU_ITEM_TYPES" (
"ID"  INTEGER NOT NULL,
"ITEM_TYPE_NAME"  TEXT,
PRIMARY KEY ("ID" ASC)
);
