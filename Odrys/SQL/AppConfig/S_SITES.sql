/*
Navicat SQLite Data Transfer

Source Server         : Odrys_AppConfig
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2013-07-02 21:12:23
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for S_SITES
-- ----------------------------
DROP TABLE IF EXISTS "main"."S_SITES";
CREATE TABLE "S_SITES" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"SITE_TITLE"  TEXT DEFAULT (null),
"VIEW_ID"  TEXT,
"VIEW_THEME_ID"  TEXT,
"LANG_ID"  TEXT,
"SITE_NAME"  TEXT,
"IS_MAIN"  INTEGER,
"S_PAGE_ID"  INTEGER,
CONSTRAINT "FK_LANG_ID" FOREIGN KEY ("LANG_ID") REFERENCES "S_LANGUAGES" ("LANG_ID")
);
