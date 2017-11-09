/*
Navicat SQLite Data Transfer

Source Server         : Odrys_AppConfig
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2013-07-02 21:12:14
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for S_PAGES
-- ----------------------------
DROP TABLE IF EXISTS "main"."S_PAGES";
CREATE TABLE "S_PAGES" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"SITE_ID"  INTEGER NOT NULL,
"PAGE_NAME"  TEXT NOT NULL,
"PAGE_TITLE"  TEXT,
"PAGE_VALUE"  TEXT
);

-- ----------------------------
-- Indexes structure for table S_PAGES
-- ----------------------------
CREATE UNIQUE INDEX "main"."IX_S_PAGES"
ON "S_PAGES" ("SITE_ID" ASC, "PAGE_NAME" ASC);
