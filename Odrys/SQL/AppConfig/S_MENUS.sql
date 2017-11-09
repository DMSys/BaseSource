/*
Navicat SQLite Data Transfer

Source Server         : Odrys_AppConfig
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2013-07-02 21:12:04
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for S_MENUS
-- ----------------------------
DROP TABLE IF EXISTS "main"."S_MENUS";
CREATE TABLE "S_MENUS" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"SITE_ID"  INTEGER NOT NULL DEFAULT (null),
"MENU_NAME"  TEXT NOT NULL,
"MENU_TEXT"  TEXT,
CONSTRAINT "FK_SITE_ID" FOREIGN KEY ("SITE_ID") REFERENCES "S_SITES" ("ID")
);

-- ----------------------------
-- Indexes structure for table S_MENUS
-- ----------------------------
CREATE UNIQUE INDEX "main"."IX_MENUS"
ON "S_MENUS" ("SITE_ID" ASC, "MENU_NAME" ASC);
