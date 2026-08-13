# Backuper CLI

A lightweight, cross-platform console application for managing directory backups and pre-restore snapshots built with **.NET 10**.

---

## Features

* **Cluster Configuration:** Pair source directories with target backup destinations under custom cluster names.
* **Timestamped Backups:** Create full directory backups with timestamped folder structures.
* **Safe Restore & Pre-Restore Snapshots:** Automatically generates a rollback snapshot (`#snapshots`) of the source directory prior to restoring a backup.
* **Undo Restore:** Roll back a restoration immediately by applying the pre-restore snapshot.
* **Automated Retention Cleaner:** Configure maximum limits for retained backups and snapshots. The cleaner automatically purges the oldest entries when thresholds are reached.
* **Multi-Language Support:** Built-in localization support for English (`EN`) and Polish (`PL`).

---

## Roadmap & Future Plans

- [ ] Graphical User Interface (GUI) implementation.
- [ ] Extended testing and dedicated binaries for Linux and macOS.
- [ ] Advanced scheduling options for automated background backups.

---

## Technical Overview

* **Target Framework:** .NET 10
* **Language:** C#
