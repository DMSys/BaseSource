/*
Navicat SQLite Data Transfer

Source Server         : Odrys_AppConfig
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2013-07-02 21:11:32
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for S_LANGUAGES
-- ----------------------------
DROP TABLE IF EXISTS "main"."S_LANGUAGES";
CREATE TABLE "S_LANGUAGES" (
"LANG_ID"  TEXT NOT NULL,
"LANG_NAME"  TEXT,
"LANG_NAME_EN"  TEXT DEFAULT (null),
PRIMARY KEY ("LANG_ID" ASC)
);

-- ----------------------------
-- Records of S_LANGUAGES
-- ----------------------------
INSERT INTO "main"."S_LANGUAGES" VALUES ('bg', 'Български', 'Bulgarian');
INSERT INTO "main"."S_LANGUAGES" VALUES ('en', 'English', 'English');
